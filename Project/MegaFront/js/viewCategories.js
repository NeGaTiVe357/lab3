const categories = document.querySelector(".categories");
const linkGet = "https://localhost:7242/api/categories";
let i = 1;

function fetchCategories() {
  fetch(linkGet)
    .then((res) => res.json())
    .then((res) => {
      categories.innerHTML = ""; // Очищаем список перед обновлением
      res.forEach((item) => {
        if (item.id !== 0) {
          // Проверяем, что id не равен 0
          categories.insertAdjacentHTML(
            "beforeend",
            `
            
<div class="row">
            <div class="form-check " style="padding-top: 10px;">
              <input
                class="form-check-input col-sm-1"
                type="checkbox"
                name="gridRadios"
                id="checkBoxCategories${i}"
                value=${item.id}
              />
              <label class="form-check-label col-sm-10 font-style-my"   for="checkBoxCategories${i}">
                ${item.name}
              </label>
              <button type="button" value="deleteButton${i}" id="deleteButton${i}" onclick="DeleteClick(${item.id}, this.id)" class="button-stile-all col-sm-1 button-delete-color" style=" border-width: 0; font-size: 10pt; 
              padding: 0.4rem 0.4rem;" >X</button>
            </div>
            
</div>
          `
          );
          i++; // Увеличиваем счетчик внутри цикла
        }
      });
    });
}

fetchCategories(); // Вызываем функцию для загрузки категорий при загрузке страницы
