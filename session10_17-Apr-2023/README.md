# session 09 - Javascript DOM

[Download Video lecture here](https://www.idrive.com/idrive/sh/sh?k=x7w9i5v5e3)

Javascript is a programming language that helps to create dynamic website. 

In a Webpage all the elements are structured as a tree like data structure where the top node is \<HTML\> and then the rest of the element become a child and subchild of this top root node.

[Click to download the video lecture](https://www.idrive.com/idrive/sh/sh?k=t7y8o9t9o0)

Document Object Model - Manipulation of the document or we can say webpage.

loops
conditions


### querying - 
we can use following methods
### GetElementsBy
- getElementById
- getElementsByName
- getElementsByClass
- getElementsByTagName

### QuerySelector
Fetches only first element from DOM
- querySelector(".button")

Fetches all elements with Id as id
querySelectorAll("#id");

### Manipulating table using JS
```JS
newRow = table.insertRow(table.rows.length);    //Inserting a new row at the end of the table

newRow.insertCell(0).innerText = table.rows.length; //Inserting a value in the first cell of a table
newRow.insertCell(1).innerText = "Sajad";
newRow.insertCell(2).innerText = "Shafi";
newRow.insertCell(3).innerText = "something";
```

### Validation using JavaScript
We can validate Form values using the Javascript
- Fetch value of a input field
- Add onchange event listener to a input field
- Modify the value
- Check if the value fullfills the requirements




```JS
fetch("Home/AddStudent", {
  method: "POST", // *GET, POST, PUT, DELETE, etc.
  body: formData, // body data type must match "Content-Type" header
}).then(response => response.json()).then(result => {
  console.log("Result: ", result);
  //$("#exampleModal").modal('hide');
  var myModalEl = document.getElementById('exampleModal');
  var modal = bootstrap.Modal.getInstance(myModalEl)
  modal.hide();
}).catch(error => {
  alert("An error occured");
  console.log(error)
});
```