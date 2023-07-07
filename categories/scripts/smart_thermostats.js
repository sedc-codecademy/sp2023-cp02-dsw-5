import headerContainer from '../../components/header.js';
import footerContainer from '../../components/footer.js';
import productCard from '../../components/productCard.js';

document.getElementById("header").appendChild(headerContainer);
document.getElementById("footer").appendChild(footerContainer);

const productsContainer = document.getElementById("products-container");

function getProducts() {
  return [
    {
      "id": 3,
      "name": "Smart Thermostat",
      "description": "Reduce your energy bills and control your home's temperature with this smart thermostat.",
      "price": 149.99,
      "imageUrl": "https://m.media-amazon.com/images/I/51E3wMYvxHL._AC_SX522_.jpg",
      "category": "thermostat"
    },
    {
      "id": 7,
      "name": "Smart Room Sensor",
      "description": "This smart room sensor works with your smart thermostat to adjust the temperature based on the room's occupancy and temperature.",
      "price": 39.99,
      "imageUrl": "https://m.media-amazon.com/images/I/612xN375tGL._AC_SX522_.jpg",
      "category": "thermostat"
    },
    {
      "id": 12,
      "name": "Smart Heating Panel",
      "description": "This smart heating panel can be controlled with your voice or phone, and features a sleek and modern design.",
      "price": 199.99,
      "imageUrl": "https://m.media-amazon.com/images/I/41HyBi7-CLL._AC_SX522_.jpg",
      "category": "thermostat"
    },
    {
      "id": 17,
      "name": "Smart Air Conditioner",
      "description": "Control your air conditioner with your voice or phone and set schedules to save energy with this smart air conditioner.",
      "price": 349.99,
      "imageUrl": "https://m.media-amazon.com/images/I/71juLwcrHjL._AC_SX522_.jpg",
      "category": "thermostat"
    }
  ]
};

getProducts().forEach(product => {
  productsContainer.innerHTML += '';
  const newProduct = productCard(product);
  productsContainer.appendChild(newProduct);
});