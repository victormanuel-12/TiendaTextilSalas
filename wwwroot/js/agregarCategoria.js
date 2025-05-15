// El script permanece igual que en el ejemplo anterior
document.addEventListener("DOMContentLoaded", () => {
  const form = document.getElementById("categoryForm");
  const categoryName = document.getElementById("categoryName");
  const categoryDescription = document.getElementById("categoryDescription");
  const categoryNameError = document.getElementById("categoryNameError");
  const categoryDescriptionError = document.getElementById(
    "categoryDescriptionError"
  );
  const cancelBtn = document.getElementById("cancelBtn");

  function showError(input, errorElement) {
    input.classList.add("invalid");
    errorElement.style.display = "block";
  }

  function hideError(input, errorElement) {
    input.classList.remove("invalid");
    errorElement.style.display = "none";
  }

  categoryName.addEventListener("blur", function () {
    this.classList.add("touched");
    if (!this.value.trim()) {
      showError(this, categoryNameError);
    } else {
      hideError(this, categoryNameError);
    }
  });

  categoryDescription.addEventListener("blur", function () {
    this.classList.add("touched");
    if (!this.value.trim()) {
      showError(this, categoryDescriptionError);
    } else {
      hideError(this, categoryDescriptionError);
    }
  });

  categoryName.addEventListener("input", function () {
    if (this.value.trim()) {
      hideError(this, categoryNameError);
    }
  });

  categoryDescription.addEventListener("input", function () {
    if (this.value.trim()) {
      hideError(this, categoryDescriptionError);
    }
  });

  form.addEventListener("submit", (e) => {
    e.preventDefault();

    categoryName.classList.add("touched");
    categoryDescription.classList.add("touched");

    let hasErrors = false;

    if (!categoryName.value.trim()) {
      showError(categoryName, categoryNameError);
      hasErrors = true;
    }

    if (!categoryDescription.value.trim()) {
      showError(categoryDescription, categoryDescriptionError);
      hasErrors = true;
    }

    if (!hasErrors) {
      alert("Categoría agregada con éxito");
      form.reset();

      categoryName.classList.remove("touched");
      categoryDescription.classList.remove("touched");
    }
  });

  cancelBtn.addEventListener("click", () => {
    form.reset();

    hideError(categoryName, categoryNameError);
    hideError(categoryDescription, categoryDescriptionError);
    categoryName.classList.remove("touched");
    categoryDescription.classList.remove("touched");
  });
});
