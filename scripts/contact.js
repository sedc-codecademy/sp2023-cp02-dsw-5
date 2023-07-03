// Import and insert header and footer components
import headerContainer from "../components/header.js";
import footerContainer from "../components/footer.js";
document.getElementById("header").appendChild(headerContainer);
document.getElementById("footer").appendChild(footerContainer);

let firstNameField = document.getElementById("contactFirstNameField");
let lastNameField = document.getElementById("contactLastNameField");
let eMailField = document.getElementById("contactEMailField");
let messageField = document.getElementById("contactSubjectField");

console.log(firstNameField)

let contactSubmitBtn = document.getElementById("exampleModal");

contactSubmitBtn.addEventListener("click", function () {
  firstNameField.innerText = "";
  lastNameField.innerHTML = "";
  eMailField.innerHTML = "";
  messageField.innerHTML= "";
});
