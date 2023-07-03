let shoppingCart = [];
let getFromStorage = sessionStorage.getItem('shoppingCart');
if(getFromStorage){
    shoppingCart = JSON.parse(getFromStorage);
}

function getCart(){
    let cartInStorage = sessionStorage.getItem('shoppingCart');
    if(cartInStorage){
        shoppingCart = JSON.parse(cartInStorage);
    }
    return shoppingCart;
}

function setCart(newCart){
    let convertedCart = JSON.stringify(newCart);
    sessionStorage.setItem('shoppingCart', convertedCart);
}

function addToCart(product){
    let cartInStorage = sessionStorage.getItem('shoppingCart');
    if(cartInStorage){
        shoppingCart = JSON.parse(cartInStorage);
    }
    shoppingCart.push(product);
    let cartString = JSON.stringify(shoppingCart);
    sessionStorage.setItem('shoppingCart', cartString);
}

function deleteById(id){
    let cartInStorage = sessionStorage.getItem('shoppingCart');
    if(cartInStorage){
        shoppingCart = JSON.parse(cartInStorage);
    }
    shoppingCart.splice(shoppingCart.findIndex(prod => prod.id === id), 1);
    let cartString = JSON.stringify(shoppingCart);
    sessionStorage.setItem('shoppingCart', cartString);
}

export { getCart, setCart, addToCart, deleteById };