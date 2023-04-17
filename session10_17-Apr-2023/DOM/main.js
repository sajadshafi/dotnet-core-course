
const table = document.getElementById("empInfo");
console.log("Table : ", table.rows.length())

let newRow = document.createElement('tr');

let newValue = document.createElement("td", {innerText:"5"});
// newValue.innerText = "4"
newRow.appendChild(newValue)

table.rows[4] = newRow;








// const incrementBtn = document.getElementById("increment");
// const decrementBtn = document.getElementById("decrement");

// const value = document.getElementById("value");


// incrementBtn.addEventListener('click', () => {
//   let number = parseInt(value.innerText);
//   value.innerText = number+1;
// });


// decrementBtn.addEventListener('click', () => {
//   let number = parseInt(value.innerText);
//   if(number > 0)
//     value.innerText = number-1;
// });


// incrementBtn.style.backgroundColor = "green";
// incrementBtn.style.color = "white";
// incrementBtn.style.padding = "10px 20px";
// incrementBtn.style.borderRadius = "10px";
// incrementBtn.style.border = "none";

// decrementBtn.style.backgroundColor = "green";
// decrementBtn.style.color = "white";
// decrementBtn.style.padding = "10px 20px";
// decrementBtn.style.borderRadius = "10px";
// decrementBtn.style.border = "none";