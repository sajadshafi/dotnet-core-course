// let form = document.getElementById("employeeForm");

// form.addEventListener('submit', function(event) {
//   event.preventDefault();    //prevents form to perform its default functionality
//   console.log("form submitted: ", event.target)

//   let employeeForm = document.forms.employeeForm;

//   let formData = new FormData(employeeForm);

//   fetch("Home/AddEmployee", {
//     method: "POST", // *GET, POST, PUT, DELETE, etc.
//     // headers: {
//     //   "Content-Type": "application/json",
//     //   // 'Content-Type': 'application/x-www-form-urlencoded',
//     // },
//     body: formData, // body data type must match "Content-Type" header
//   }).then(response => response.json()).then(result => {
//     console.log("Result : ", result)
//   }).catch(error => {
//     console.error("Error: ", error)
//   });
//   // const result = await response.json(); // parses JSON response into native JavaScript objects

// });

//Ajax, Fetch, axios

//fetch(url, {
//  method, body, headers
//})


// var , let , const   -> int, boolean, decimal, string



// function AddEmployee(e) {
//   e.preventDefault();

//   var formEl = document.forms.studentForm;
//   var formData = new FormData(e.target);
//   fetch("Home/AddEmployee", {
//     method: "POST", // *GET, POST, PUT, DELETE, etc.
//     body: formData, // body data type must match "Content-Type" header
//   }).then(response => response.json()).then(result => {
//     console.log("Result: ", result);
//     //$("#exampleModal").modal('hide');
//     // var myModalEl = document.getElementById('exampleModal');
//     // var modal = bootstrap.Modal.getInstance(myModalEl)
//     // modal.hide();
//   }).catch(error => {
//     alert("An error occured");
//     console.error("Error: ", error)
//   });
// }

// form.addEventListener('submit', AddEmployee);

    