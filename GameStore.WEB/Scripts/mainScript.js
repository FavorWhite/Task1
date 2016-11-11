$('.carousel').carousel({
    interval: 2000
})
$('.dropdown-subgenre-btn').on('click', function () {
    var _this = $(this);

    _this.toggleClass('selected').parent().next('.subgenres').slideToggle();

});