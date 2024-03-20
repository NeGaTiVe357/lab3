function DeleteClick(id, buttonId) {
  const inputValue = {
    id: id,
    name: "string",
  };
  const url = "https://localhost:7242/api/categories";

  // Удаляем элемент с формой
  const headers = {
    Accept: "application/json, text/plain, */*",
    "Content-Type": "application/json;charset=utf-8",
  };
  fetch(url, {
    method: "Delete",

    body: JSON.stringify(inputValue),
    headers: headers,
  })
    .then((response) => {
      if (response.ok) {
        fetchCategories(); // Обновляем список категорий после успешного сохранения
      } else {
        throw new Error("Ошибка при сохранении новой категории");
      }
    })
    .catch((error) => {
      console.error("Ошибка:", error);
    });
}
