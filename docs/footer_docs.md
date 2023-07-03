# Incorporating the footer component

### to incorporate the footer component inside your page just add a new tag in your html and give it an id.
```html
<footer id="footer"></footer>
```
### then in your javascript import the component using a relative path
```javascript
import footerContainer from "../components/footer.js";
```
### and finally append the `footerContainer` in the footer tag u created using dom
```javascript
document.getElementById("footer").appendChild(footerContainer);
```