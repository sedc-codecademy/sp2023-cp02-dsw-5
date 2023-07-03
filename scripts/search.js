// Import and insert header and footer components
import headerContainer from "../components/header.js";
import footerContainer from "../components/footer.js";
import { SearchByKeyword } from "../services/product_service.js"
document.getElementById("header").appendChild(headerContainer);
document.getElementById("footer").appendChild(footerContainer);

// Keep this on top
// The search string of the user is available in the keyword constant you see here
const searchString = new URLSearchParams(window.location.search);
const keyword = searchString.get('search');

function renderResults(results) {
    const searchResultsDiv = document.getElementById("searchResults");
    searchResultsDiv.innerHTML = "";
    if (results.length === 0) {
      searchResultsDiv.innerHTML = "No results found.";
      return;
    }
    results.forEach(result => {
      const resultContainer = document.createElement("div");
      resultContainer.innerHTML = `
        <h2>${result.name}</h2>
        <img src="${result.imageUrl}" alt="${result.name}">
        <p>${result.description}</p>
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