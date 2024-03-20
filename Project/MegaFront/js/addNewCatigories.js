function addClick() {
    categories.insertAdjacentHTML(
      "beforeend",
      `
      <div id="AddCategoryForm">
        <label for="inputCategory" class="col-sm-2 col-form-label font-style-my">New Categories</label>
        <div class="col-sm-10">
          <input
            type="email"
            class="input-style-my font-style-my"
            id="inputCategory"
            placeholder="New Categories"
          />
          </div>
          </div>
      `
    );
    const addButton = document.getElementById("addCategories");
  
    addButton.onclick = saveNewCategory;
  }
  
  function saveNewCategory() {
    const elementToRemove = document.getElementById("AddCategoryForm");
    const inputElement = document.getElementById("inputCategory");
    let inputValue = inputElement.value;
    if(inputValue != ''){
        inputValue = {
            "name": inputValue
           }
          const url = "https://localhost:7242/api/categories";
           console.log(inputValue)
          // Удаляем элемент с формой
          const headers = {
            'Accept': "application/json, text/plain, */*",
                        'Content-Type': "application/json;charset=utf-8"
          }
          fetch(url,{
            method: 'POST',
            
            body:  JSON.stringify(inputValue),
            headers: headers
          })
          .then(response => {
            if (response.ok) {
              fetchCategories(); // Обновляем список категорий после успешного сохранения
              elementToRemove.remove();
              const addButton = document.getElementById("addCategories");
              addButton.onclick = addClick;
            } else {
              throw new Error('Ошибка при сохранении новой категории');
            }
          })
          .catch(error => {
            console.error('Ошибка:', error);
          });
    }
    
  }
  