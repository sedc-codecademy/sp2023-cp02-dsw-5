# Using the search page

Redirecting the user to the search page can be done via the root path using the basePath constant in the helpers the easiest way to do this is with a simple form submission with a get request that needs to have one query parameter called `search`.

```html
<form action="./search.html" method="GET">
    <input name="search">
    <input type="submit" value="Search">
</form>
```

After the user arrives at the search page their query is parsed using `URLSearchParams` and is available in the `keyword` constant in `search.js`.

```javascript
const searchString = new URLSearchParams(window.location.search);
const keyword = searchString.get('search');
```