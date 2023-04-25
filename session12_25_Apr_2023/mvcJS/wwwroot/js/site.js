function DeleteEmployee(target) {
  let id = target.getAttribute("data-id");

  // var myModalEl = document.getElementById('confirmDialog');
  // var modal = bootstrap.Modal.getInstance(myModalEl)

  var modal = new bootstrap.Modal(document.getElementById('confirmDialog'))
  modal.show();

  document.getElementById("confirmDelete").addEventListener('click', () => {
    fetch("Home/DeleteEmployee?id=" + id, {
      method: "POST"
    })
    .then(response => response.text())
    .then(result => {
      console.log("Delete: ", result)
      let currentEmployee = document.getElementById(result);
      currentEmployee.parentElement.removeChild(currentEmployee);
    })
    .catch(error => {
      console.log(error)
    })
  });
}

function EditEmployee(target) {
  let emp = target.getAttribute("data-item");
  console.log("Edit clicked");
}