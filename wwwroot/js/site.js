﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var mySwiper = new Swiper('.swiper-container', {

    slidesPerView: 1,
    autoplay: {
        delay: 2000,
    },
    // Scrollbar
    scrollbar: {
        el: '.swiper-scrollbar',
    },
})