// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var mySwiper = new Swiper('.swiper-container', {
    // Optional parameters
    // If we need pagination
    slidesPerView : 1,

    // Navigation arrows

    // And if we need scrollbar
    scrollbar: {
        el: '.swiper-scrollbar',
    },
})