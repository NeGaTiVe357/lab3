const postList = document.querySelector(".postList");
const linkGet = "https://localhost:7242/api/product";

function getProduct() {
  fetch(linkGet)
    .then((res) => res.json())
    .then((res) => {
      postList.innerHTML = ""; // Очищаем список перед добавлением новых карточек
      res.forEach((item) => {
        console.log(item); // Выводим содержимое переменной item в консоль
        postList.insertAdjacentHTML(
          "beforeend",
          `<div class="post" style="padding: 20px">
                <div class="card" style="width: 18rem; height: 100%">
                <img src="/img/${
                  item.nameImg ?? "drive"
                }.jpg" class="card-img-top" alt="..." />
                <div class="card-body">
                    <h5 class="card-title">${item.productName}</h5>
                    <p class="card-text"> ${
                      item.description ?? "No description"
                    } </p>
                    <p class="card-text">Price: ${
                      item.price
                    } </p>                
                    <p class="card-text">Quantity ${item.quantity} </p>
                    <a href="#" onclick="editFunction('${item.idProduct}', '${item.productName}',
                        '${item.description}', '${item.nameImg}', '${item.price}',
                        '${item.quantity}', '${item.category}')" class="button-stile-all">Edit</a>
                    <a href="#" class="button-stile-all button-delete-color" onclick="deleteFunction('${item.idProduct}')">Delete</a>
    
                </div>
            </div>
          </div>`
        );
      });
    });
}

getProduct();
