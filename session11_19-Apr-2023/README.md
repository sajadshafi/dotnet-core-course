## Session 11 - Continuing Javascript DOM and Fetching methods

[Download Video lecture here](https://www.idrive.com/idrive/sh/sh?k=g1y0p3o5v2)


### Fix previous problem:
- FIXME: form submission returns an error -> something is not a valid json
  solution: - instead of response.json we must use response.text

### Manipulating table using JS
```JS
newRow = table.insertRow(table.rows.length);    //Inserting a new row at the end of the table

newRow.insertCell(0).innerText = table.rows.length; //Inserting a value in the first cell of a table
newRow.insertCell(1).innerText = "Sajad";
newRow.insertCell(2).innerText = "Shafi";
newRow.insertCell(3).innerText = "something";
```

#### Closing model after form is submitted successfully!
```JS
//$("#exampleModal").modal('hide');
  var myModalEl = document.getElementById('exampleModal');
  var modal = bootstrap.Modal.getInstance(myModalEl)
  modal.hide();
```