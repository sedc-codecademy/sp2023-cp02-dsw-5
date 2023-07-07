import headerContainer from '../../components/header.js';
import footerContainer from '../../components/footer.js';
import { deleteById, getCart, setCart } from '../../helpers/session_cart.js';


document.getElementById("header").appendChild(headerContainer);
document.getElementById("footer").appendChild(footerContainer);

const shoppingCart = document.getElementById("shoppingCart");
const clearCartBtn = document.querySelector('.clear-cart');
const totalCartBtn = document.querySelector('.cart-total');
const deleteBtn = document.getElementById('deleteBtn');



let proceedToPayBtn = document.getElementById('proceedToPay');

function GetToCheckoutPage(){
  location.href = "checkout.html";
}
proceedToPayBtn.addEventListener("click", GetToCheckoutPage);
let cart = getCart();
// let cart = [{"id": 2,
// "name": "Smart Plug",
// "description": "Turn any device into a smart device with this easy-to-use smart plug.",
// "price": 24.99,
// "imageUrl": "#",
// "category": "plug"},
// {"id": 3,
// "name": "Smart Plug",
// "description": "Turn any device into a smart device with this easy-to-use smart plug.",
// "price": 24.99,
// "imageUrl": "#",
// "category": "plug"}];

clearCartBtn.addEventListener('click', () => {
  setCart([]);
  cart = getCart();
  sumProductPrices();
  renderProducts(cart);
})

cart = cart.map(product => {
  return {
    ...product,
    numberOfUnits: 1
  };
})

function sumProductPrices(){
  let totalPrice = 0;
  
  cart.forEach(product => {
    totalPrice += product.price * product.numberOfUnits;
  })
  totalCartBtn.innerHTML = totalPrice.toFixed(2);
}

sumProductPrices(cart);

function changeNumberOfUnits(action, id){
  cart = cart.map((product) =>{
    if (product.id != id) {
      return product;
    }
    const {numberOfUnits} = product;
    const updatedNumberOfUnits = action === "plus"
    ?numberOfUnits + 1 
    : numberOfUnits -1;
     
    
    return {
      ...product,
      numberOfUnits : Math.max(1, updatedNumberOfUnits),
    };
    
  });
  renderProducts(cart);
  sumProductPrices(cart);
  
};
window.changeNumberOfUnits = changeNumberOfUnits;


renderProducts(cart);


function renderProducts(cart) {
  console.log(cart);
  if(cart.length === 0){
    shoppingCart.innerHTML = `<div class="container"><h2 class="display-4">You have no items in your cart</h2></div>`;
    return;
  }
  shoppingCart.innerHTML = "";
  cart.forEach((product) =>{
    shoppingCart.innerHTML += `
    <div class="d-flex flex-row justify-content-between align-items-center px-lg-5 mx-lg-5 mobile" id="heading">
      <div class="px-lg-5 mr-lg-5 " id="produc">PRODUCTS</div>
      <div class="px-lg-5 ml-lg-5" id="prc">PRICE</div>
      <div class="px-lg-5 ml-lg-1" id="quantity">QUANTITY</div>
    </div>
    <div class="d-flex flex-row justify-content-between align-items-center pt-lg-4 pt-2 pb-3 border-bottom mobile row">
      <div class="d-flex flex-row align-items-center col">
        <div><img src="${product.imageUrl}" width="150" height="150" alt="" id="image"></div>
        <div class="d-flex flex-column pl-md-3 pl-1 col">
        <div><h6>${product.name}</h6></div>
      </div>                    
    </div>
    <div class="px-lg-5 ml-lg-5 col"><b>$${product.price}</b></div>
    <div class="d-flex flex-row justify-content-between align-items-center pt-lg-4 pt-2 pb-3 mobile col">
      <div class="btn minus" onclick="changeNumberOfUnits('minus', ${product.id})">-</div>
      <div class="number">${product.numberOfUnits}</div>
      <div class="btn plus" onclick="changeNumberOfUnits('plus', ${product.id})">+</div>
      <div class="btn btn-danger btn-sm delete-btn close" id="deleteBtn">&times;</div>
    </div>
    `
  });
};