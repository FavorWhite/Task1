$('.carousel').carousel({
    interval: 2000
})
$('.dropdown-subgenre-btn').on('click', function () {
    var _this = $(this);
    if (_this.hasClass('selected')) {
        _this.removeClass('selected').parent().next('.subgenres').slideUp();
    } else {
        _this.parent().siblings().children(".dropdown-subgenre-btn").removeClass('selected').parent().next('.subgenres').slideUp();
        _this.parent().next('.subgenres').addBack().addClass('selected').slideDown();
    }
});