# Incorporating the header component

### to incorporate the header component inside your page just add a new tag in your html and give it an id.
```html
<header id="header"></header>
```
### then in your javascript import the component using a relative path
```javascript
import headerContainer from "../components/header.js";
```
### and finally append the `headerContainer` in the header tag u created using dom
```javascript
document.getElementById("header").appendChild(headerContainer);
```