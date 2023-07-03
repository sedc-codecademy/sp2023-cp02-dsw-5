import headerContainer from '../../components/header.js';
import footerContainer from '../../components/footer.js';
import productCard from '../../components/productCard.js';

document.getElementById("header").appendChild(headerContainer);
document.getElementById("footer").appendChild(footerContainer);

const productsContainer = document.getElementById("products-container");

function getProducts() {
  return [
    {
      "id": 5,
      "name": "Smart Speaker with Alexa",
      "description": "This smart speaker with Alexa allows you to control your smart home devices, play music, and get information with your voice.",
      "price": 99.99,
      "imageUrl": "https://m.media-amazon.com/images/I/61UP5puPUqL._AC_SX679_.jpg",
      "category": "speaker"
    },
    {
      "id": 9,
      "name": "Smart Soundbar",
      "description": "Improve your home theater experience with this smart soundbar, which features voice control and streaming capabilities.",
      "price": 249.99,
      "imageUrl": "https://m.media-amazon.com/images/I/61v+-9dV4PL._AC_SX679_.jpg",
      "category": "speaker"
    },
    {
      "id": 14,
      "name": "Smart Portable Speaker",
      "description": "Take your music with you wherever you go with this smart portable speaker, which features a waterproof design and voice control.",
      "price": 149.99,
      "imageUrl": "https://m.media-amazon.com/images/I/71maGClYISL._AC_SY879_.jpg",
      "category": "speaker"
    },
    {
      "id": 19,
      "name": "Smart Bookshelf Speaker",
      "description": "Enjoy high-quality sound and voice control with these smart bookshelf speakers, which can be integrated with your smart home system.",
      "price": 299.99,
      "imageUrl": "https://m.media-amazon.com/images/I/51RxuXa-Q3L._AC_SX679_.jpg",
      "category": "speaker"
    }
  ]
};

getProducts().forEach(product => {
  console.log(product);
  productsContainer.innerHTML += '';
  const newProduct = productCard(product);
  productsContainer.appendChild(newProduct);
});