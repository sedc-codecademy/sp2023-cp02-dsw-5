import headerContainer from '../../components/header.js';
import footerContainer from '../../components/footer.js';
import { getCart } from '../../helpers/session_cart.js';

document.getElementById("header").appendChild(headerContainer);
document.getElementById("footer").appendChild(footerContainer);

let checkoutBtn = document.querySelector(".btn-submitCheckout");

checkoutBtn.addEventListener("click", function() {
    let userFullName = document.querySelector("#fname").value = "";
    let userEMail = document.querySelector("#email").value = "";
    let userAddress = document.querySelector("#address").value = "";
    let userCity = document.querySelector("#city").value = "";
    let userZipCode = document.querySelector("#zip").value = "";
    let userState = document.querySelector("#state").value = "";
    let userCardName = document.querySelector("#cardName").value = "";
    let userCreditCardNumber = document.querySelector("#creditCardNumber").value = "";
    let userCreditCardExpiryMonth = document.querySelector("#expiryMonth").value = "";
    let userCardExpiryYear = document.querySelector("#expiryYear").value = "";
    let userCreditCardCVV = document.querySelector("#cvv").value = "";
});