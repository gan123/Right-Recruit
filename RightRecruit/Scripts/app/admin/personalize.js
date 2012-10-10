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
            $('#basic').val('#' + hex);
            $('#basic').css('backgroundColor', '#' + hex);
            $('.menu-mini').css('backgroundColor', '#' + hex);
        }
    });
    
    $("#mid").ColorPicker({
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
            $('#mid').val('#' + hex);
            $('#mid').css('backgroundColor', '#' + hex);
        }
    });
    
    $("#bold").ColorPicker({
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
            $('#bold').val('#' + hex);
            $('#bold').css('backgroundColor', '#' + hex);
        }
    });
});