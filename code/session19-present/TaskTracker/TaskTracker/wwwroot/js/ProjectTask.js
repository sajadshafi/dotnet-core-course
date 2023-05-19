function DeleteTask(target) {
    let id = target.getAttribute("data-id");

    // var myModalEl = document.getElementById('confirmDialog');
    // var modal = bootstrap.Modal.getInstance(myModalEl)

    let modal = new bootstrap.Modal(document.getElementById('confirmDialog'))
    modal.show();

    document.getElementById("confirmDelete").addEventListener('click', () => {
        fetch("task/deletetask?taskid=" + id, {
            method: "POST"
        })
            .then(response => response.json())
            .then(result => {
                console.log("REsult : ", result)
                console.log("Current Task id : ", result.data);
                let currentTask = document.getElementById(result.data);
                console.log("Current Task : ", currentTask);
                currentTask.parentElement.removeChild(currentTask);
                modal.hide();
            })
            .catch(error => {
                console.log(error)
            })
    });
}

function EditTask(target) {
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
                if (key != 'id')
                    editModel.querySelector(`input[name=${key}]`).value = result[key];
            })

            document.getElementById("editEmployeeForm").addEventListener("submit", (event) => UpdateEmployee(event, result.id))
        })
        .catch(error => {
            console.log(error)
        })
}