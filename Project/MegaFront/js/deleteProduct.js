function deleteFunction(id){

    const body = {
        "id": id
         }
        const url = "https://localhost:7242/api/product";
        // Удаляем элемент с формой
        const headers = {
          'Accept': "application/json, text/plain, */*",
                      'Content-Type': "application/json;charset=utf-8"
        }
        fetch(url,{
          method: 'DELETE',
          
          body:  JSON.stringify(body),
          headers: headers
        })
        .then(response => {
          if (response.ok) {
            getProduct();
             // Обновляем список категорий после успешного сохранения
          } else {
            throw new Error('Ошибка при сохранении новой категории');
          }
        })
        .catch(error => {
          console.error('Ошибка:', error);
        });

}