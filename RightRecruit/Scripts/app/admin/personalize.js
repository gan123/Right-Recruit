$(function() {
    $("#basic").ColorPicker({
        color: '#0094cd',
        onShow: function (colpkr) {
            $(colpkr).fadeIn(500);
            return false;
        },
        onHide: function (colpkr) {
            $(colpkr).fadeOut(500);
            return false;
        },
        onChange: function (hsb, hex, rgb) {
            $('#basic').css('backgroundColor', '#' + hex);
        }
    });
});