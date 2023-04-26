function DeleteEmployee(target) {
  let id = target.getAttribute("data-id");

  // var myModalEl = document.getElementById('confirmDialog');
  // var modal = bootstrap.Modal.getInstance(myModalEl)

  let modal = new bootstrap.Modal(document.getElementById('confirmDialog'))
  modal.show();

  document.getElementById("confirmDelete").addEventListener('click', () => {
    fetch("Home/DeleteEmployee?id=" + id, {
      method: "POST"
    })
    .then(response => response.text())
    .then(result => {
      let currentEmployee = document.getElementById(result);
      currentEmployee.parentElement.removeChild(currentEmployee);
    })
    .catch(error => {
      console.log(error)
    })
  });
}

function EditEmployee(target) {
  let id = target.getAttribute("data-item");
  console.log("Current Employee id: ", id)
  fetch("Home/GetEmployeeById/" + id, {
    method: "GET"
  })
  .then(response => response.json())
  .then(result => {

    const editModel = document.getElementById('editEmployeeModal');
    let modal = new bootstrap.Modal(editModel);
    modal.show();

    // //select and set value seperately
    // const nameField = editModel.querySelector("input[name=name]");
    // nameField.value = result.name;

    // //select and set value in single statement
    // editModel.querySelector("[name=phone]").value = result.phone;
    // editModel.querySelector("[name=email]").value = result.email;


    //Or in a single loop
    
    Object.keys(result).forEach(key => {
      if(key != 'id')
        editModel.querySelector(`input[name=${key}]`).value = result[key];
    })

    document.getElementById("editEmployeeForm").addEventListener("submit", (event) => UpdateEmployee(event, result.id))
  })
  .catch(error => {
    console.log(error)
  })
}

function UpdateEmployee(event, id) {
  event.preventDefault();

  var formData = new FormData(event.target);
  formData.append("id", id);

    //axios
    fetch("Home/UpdateEmployee", {
        method: "POST",
        body: formData,
    })
    .then(response => response.json())
    .then(result => {
      console.log("Updated Employee : ", result)

      let currentEmployee = document.getElementById(result.id);
      currentEmployee.parentElement.removeChild(currentEmployee);

      const empList = document.getElementById("employeeList");

      let newRowString = `<tr>
            <td>${result.id}</td>
            <td>${result.name}</td>
            <td>${result.phone}</td>
            <td>${result.email}</td>
            <td>
              <div>
                  <button onclick="EditEmployee(this)" data-item=${result.id} class="btn btn-warning">Edit</button>
                  <button onclick="DeleteEmployee(this)" data-id=${result.id} class="btn btn-danger">Delete</button>
              </div>
          </td>
        </tr>`;

      empList.innerHTML = newRowString + empList.innerHTML;

      // let modal = new bootstrap.Modal(document.getElementById('editEmployeeModal'));
      // modal.hide();

      //Second way of adding row to a table
      var myModalEl = document.getElementById('editEmployeeModal');
      var modal = bootstrap.Modal.getInstance(myModalEl)
      modal.hide();

    })
    .catch(error => {
      console.log(error);
    });
}