function editFunction(id, name, description, nameImg, price, quantity, categories){
    // Определяем имя новой функции, которое нужно назначить кнопке
const newFunctionName = 1;

// Формируем URL с параметрами, включая имя новой функции
const url = `AddProduct.html?id=${id}&name=${encodeURIComponent(name)}&description=${encodeURIComponent(description)}&nameImg=${encodeURIComponent(nameImg)}&price=${price}&quantity=${quantity}&newFunctionName=${encodeURIComponent(newFunctionName)}`;

// Переходим на страницу AddProduct.html с формированным URL
window.location.href = url;

}
function editProduct(id){
    const name = document.getElementById("inputName").value;
    const description = document.getElementById("inputDescription").value;
    const nameImg = document.getElementById("inputNameImg").value;
    const price = parseFloat(document.getElementById("inputPrice").value);
    const quantity = parseInt(document.getElementById("inputQuantity").value);
    const selectedCategories = collectSelectedCategories();
    
    if(name !== '' && !isNaN(price) && !isNaN(quantity)){
      
        const body = {
            "id": id,
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
            method: 'PUT',
            
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
    const editButton = document.getElementById('addProduct');
// Устанавливаем новую функцию onclick
editButton.setAttribute('onclick', `addProductClick()`);
    window.location.href = 'ProductMenu.html';
}