$.fn.numerico = function (options) {

    var defaults = {
        allowNegatives: false,
        allowDecimal: false
    };

    defaults = $.extend(defaults, options);

    $(this).on("keypress", function (event) {

        var key = (event.which) ? event.which : event.keyCode;
        var char = event.charCode;

        if (!event.shiftKey
		&& !event.ctrlKey
		&& !event.altKey
		&& ((key >= 48 && key <= 57)
		|| key == 8
		|| key == 45
		|| key == 44
	)) {
            if (defaults.allowNegatives == false && (key == 45)) {
                return false;
            }
            else if 
		(
				defaults.allowNegatives == true
			&& $(this).val().length > 0
			&& (key == 45)
		) {
                return false;
            }

            if (
				defaults.allowDecimal == false
			&& (key == 44)
		) {
                return false;
            }
            else if (defaults.allowDecimal == true) {
                if ($(this).val().length == 0) {
                    if ((key == 44)) {
                        return false;
                    }
                }
                else {
                    if ((key == 44)) {
                        for (var i = 0; i < $(this).val().length; i++) {
                            if ($(this).val().charAt(i) == ",") {
                                return false;
                            }
                        }
                    }
                }
            }
        }
        else if (
			key == 0
		|| key == 127
        || key == 9
	)
        { }
        else {
            return false;
        }
    });

    $.fn.obterValor = function () {
        if ($.trim($(this).val()) != "") {
            return obterValorFloat($(this).val());
        }
        return null;
    }
};