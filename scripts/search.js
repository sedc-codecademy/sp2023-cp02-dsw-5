// Import and insert header and footer components
import headerContainer from "../components/header.js";
import footerContainer from "../components/footer.js";
import { SearchByKeyword } from "../services/product_service.js";
import productCard from "../components/productCard.js";
document.getElementById("header").appendChild(headerContainer);
document.getElementById("footer").appendChild(footerContainer);

// Keep this on top
// The search string of the user is available in the keyword constant you see here
const searchString = new URLSearchParams(window.location.search);
const keyword = searchString.get('search');
const searchTitle = document.getElementById("search-title");
searchTitle.innerText = `Search results for: ${keyword}`;

function renderResults(results) {
    const searchResultsDiv = document.getElementById("searchResults");
    searchResultsDiv.innerHTML = "";
    if (results.length === 0) {
      searchResultsDiv.innerHTML = `
        <div class="container">
          <h2 class="display-3">No results found</h2>
        </div>
      `;
      return;
    }
    results.forEach(result => {
      const resultContainer = document.createElement("div");
      resultContainer.classList="d-flex flex-column search-card";
      resultContainer.innerHTML = `
      <img src="${result.imageUrl}" class="search-img" alt="Card image cap">
      <div class="card-heder">
        <h5 class="card-title">${result.name}</h5>
        <p class="card-text">${result.description}</p>
      </div>
      `;
      searchResultsDiv.appendChild(resultContainer);
    });
}

document.querySelector(".btn").addEventListener("click", search);
function search() {
  // const keyword = document.querySelector(".me-2").value;
  const results = SearchByKeyword(keyword);
  renderResults(results);
}
search();

// <h2>${result.name}</h2>
// <img src="${result.imageUrl}" alt="${result.name}">
// <p>${result.description}</p>