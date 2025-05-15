const dropZone = document.getElementById("dropZone");
const fileInput = document.getElementById("fileInput");
const imagePreview = document.getElementById("imagePreview");
const fileInfo = document.getElementById("fileInfo");
const fileName = document.getElementById("fileName");

const updateBtn = document.getElementById("updateBtn");
const deleteBtn = document.getElementById("deleteBtn");
const cancelBtn = document.getElementById("cancelBtn");

dropZone.addEventListener("click", () => {
  fileInput.click();
});

["dragenter", "dragover", "dragleave", "drop"].forEach((eventName) => {
  dropZone.addEventListener(eventName, preventDefaults, false);
});

function preventDefaults(e) {
  e.preventDefault();
  e.stopPropagation();
}

["dragenter", "dragover"].forEach((eventName) => {
  dropZone.addEventListener(eventName, highlight, false);
});

["dragleave", "drop"].forEach((eventName) => {
  dropZone.addEventListener(eventName, unhighlight, false);
});

function highlight() {
  dropZone.style.borderColor = "#0066cc";
  dropZone.style.backgroundColor = "rgba(0, 102, 204, 0.05)";
}

function unhighlight() {
  dropZone.style.borderColor = "#ccc";
  dropZone.style.backgroundColor = "";
}

dropZone.addEventListener("drop", handleDrop, false);
fileInput.addEventListener("change", handleFiles, false);

function handleDrop(e) {
  const dt = e.dataTransfer;
  const files = dt.files;
  handleFiles({ target: { files } });
}

function handleFiles(e) {
  const files = e.target.files;
  if (files.length) {
    const file = files[0];
    if (file.type.match("image.*")) {
      const reader = new FileReader();

      reader.onload = function (e) {
        imagePreview.src = e.target.result;
        imagePreview.style.display = "block";

        fileInfo.style.display = "flex";
        fileName.textContent = file.name;

        document.querySelector(
          ".file-thumbnail"
        ).style.backgroundImage = `url(${e.target.result})`;
        document.querySelector(".file-thumbnail").style.backgroundSize =
          "cover";
        document.querySelector(".file-thumbnail").style.backgroundPosition =
          "center";

        simulateUpload();
      };

      reader.readAsDataURL(file);
    }
  }
}

function simulateUpload() {
  const progressBar = document.querySelector(".file-progress-bar");
  progressBar.style.width = "0%";

  let progress = 0;
  const interval = setInterval(() => {
    progress += 5;
    progressBar.style.width = `${progress}%`;

    if (progress >= 100) {
      clearInterval(interval);
    }
  }, 50);
}

updateBtn.addEventListener("click", () => {
  alert("Producto actualizado correctamente");
});

deleteBtn.addEventListener("click", () => {
  if (confirm("¿Está seguro que desea eliminar este producto?")) {
    alert("Producto eliminado correctamente");
  }
});

cancelBtn.addEventListener("click", () => {
  if (
    confirm(
      "¿Está seguro que desea cancelar? Los cambios no guardados se perderán."
    )
  ) {
    window.location.href = "#";
  }
});
