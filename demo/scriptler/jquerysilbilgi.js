$(document).ready(function () {
	$('#bilgisil').click(function (e) {

		e.preventDefault();

		$.confirm({
			title: 'Silecek misiniz!?',
			content: 'Devam Etmek İstediğinizden Eminmisiniz?',
			autoClose: 'Hayır|10000',
			theme: 'dark',
			icon: 'fa fa-warning',
			animation: 'blur',
			buttons: {
				Evet: function () {
					$("#formsil").submit();
				},
				Hayır: function () {

				},

			}

		});
	});
});
