$(document).ready(function(){

    $(function (){
		$("#back-top").hide();

		$(window).scroll(function (){
			if ($(this).scrollTop() > 700){
				$("#back-top").fadeIn();
			} else{
				$("#back-top").fadeOut();
			}
		});

		$("#back-top a").click(function (){
			$("body,html").animate({
				scrollTop:0
			}, 800);
			return false;
		});
	});
});


$.datetimepicker.setLocale('uk');

$('#datetimepicker_format').datetimepicker({ value: '2015/04/15 05:03', format: $("#datetimepicker_format_value").val() });
$("#datetimepicker_format_change").on("click", function (e) {
    $("#datetimepicker_format").data('xdsoft_datetimepicker').setOptions({ format: $("#datetimepicker_format_value").val() });
});
$("#datetimepicker_format_locale").on("change", function (e) {
    $.datetimepicker.setLocale($(e.currentTarget).val());
});
$('#datetimepicker').datetimepicker({
    dayOfWeekStart: 1,
    lang: 'uk',
    disabledDates: ['1986/01/08', '1986/01/09', '1986/01/10'],
    startDate: '1986/01/05'
});
$('#datetimepicker').datetimepicker({ value: '2015/04/15 05:03', step: 10 });

$('.some_class').datetimepicker({ format: "d/m/Y H:i" });
$('#datetimepicker_dark').datetimepicker({ theme: 'dark' });
