import { basePath } from "../helpers/constants.js";

const footerContainer = document.createElement("footer");
footerContainer.className = "bg-dark text-white py-4";
footerContainer.innerHTML = `
  <div class="container">
    <div class="row">
      <div class="col-md-4">
        <h5 class="text-uppercase mb-3">Shipfinity</h5>
        <p>© 2023 Shipfinity, Inc</p>
      </div>

      <div class="col-md-4">
        <h5 class="text-uppercase mb-3">Categories</h5>
        <ul class="list-unstyled">
          <li><a href="${basePath}/categories/smart_lights.html" class="text-decoration-none text-white">Smart Lights</a></li>
          <li><a href="${basePath}/categories/smart_plugs.html" class="text-decoration-none text-white">Smart Plugs</a></li>
          <li><a href="${basePath}/categories/smart_speakers.html" class="text-decoration-none text-white">Smart Speakers</a></li>
          <li><a href="${basePath}/categories/smart_thermostats.html" class="text-decoration-none text-white">Smart Thermostats</a></li>
          <li><a href="${basePath}/categories/wifi_extenders.html" class="text-decoration-none text-white">Wi-Fi Extenders</a></li>
        </ul>
      </div>

      <div class="col-md-4">
        <h5 class="text-uppercase mb-3">Connect with us</h5>
        <ul class="nav list-unstyled d-flex">
        <li class="ms-3"><a class="text-muted" href="https://twitter.com/your_profile" target="_blank"><img src="${basePath}/assets/footer_social_images/twitter.svg" alt="Twitter" width="24" height="24"></a></li>
        <li class="ms-3"><a class="text-muted" href="https://facebook.com/your_profile" target="_blank"><img src="${basePath}/assets/footer_social_images/facebook.svg" alt="Facebook" width="24" height="24"></a></li>
        <li class="ms-3"><a class="text-muted" href="https://youtube.com/your_profile" target="_blank"><img src="${basePath}/assets/footer_social_images/youtube.svg" alt="YouTube" width="24" height="24"></a></li>
        <li class="ms-3"><a class="text-muted" href="https://instagram.com/your_profile" target="_blank"><img src="${basePath}/assets/footer_social_images/instagram.svg" alt="Instagram" width="24" height="24"></a></li>
        </ul>
      </div>
    </div>
  </div>`;

export default footerContainer;
