function addProductClick(){
    const name = document.getElementById("inputName").value;
    const description = document.getElementById("inputDescription").value;
    const nameImg = document.getElementById("inputNameImg").value;
    const price = parseFloat(document.getElementById("inputPrice").value);
    const quantity = parseInt(document.getElementById("inputQuantity").value);
    const selectedCategories = collectSelectedCategories();
    
    if(name !== '' && !isNaN(price) && !isNaN(quantity)){
      
        const body = {
          "name": name,
          "description": description,
          "nameImg": nameImg,
          "price": price,
          "quantity": quantity,
          "category": selectedCategories
           }
          const url = "https://localhost:7242/api/product";
          // Удаляем элемент с формой
          const headers = {
            'Accept': "application/json, text/plain, */*",
                        'Content-Type': "application/json;charset=utf-8"
          }
          fetch(url,{
            method: 'POST',
            
            body:  JSON.stringify(body),
            headers: headers
          })
          .then(response => {
            if (response.ok) {
              fetchCategories(); // Обновляем список категорий после успешного сохранения
            } else {
              throw new Error('Ошибка при сохранении новой категории');
            }
          })
          .catch(error => {
            console.error('Ошибка:', error);
          });
    }
    window.location.href = 'ProductMenu.html';
    
}

function collectSelectedCategories() {
    const selectedCategories = []; // Создаем пустой массив для хранения id выбранных категорий
    const checkboxes = document.querySelectorAll('.form-check-input'); // Получаем все чекбоксы

    checkboxes.forEach(checkbox => {
        if (checkbox.checked) { // Проверяем, был ли чекбокс выбран
            selectedCategories.push(checkbox.value); // Если выбран, добавляем его id в список
        }
    });

    return selectedCategories; // Возвращаем список выбранных категорий
}

// Пример использования:

