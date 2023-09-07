(function ($) {
    "use strict";

    $(document).ready(function ($) {
        // stikcy js
        var ct = $("#sticker").sticky({
            topSpacing: 0,
            listen: true
          
        });
    });

    jQuery(window).on("load", function () {
        jQuery(".loader").fadeOut(1000);
    });


}(jQuery));