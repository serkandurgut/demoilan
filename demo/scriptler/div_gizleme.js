$(document).ready(function () {
	$('#calisiyormu').change(function () {
		 
		if (this.checked)
			$('#kapa').hide("slide", { direction: "left" }, 500);
		else
			$('#kapa').show("slide", { direction: "left" }, 500);

	});
	$('#calisiyormu').trigger('change');
});

$(document).ready(function () {
	$('#terk').change(function () {
		var attr = $('#egitimID option:selected').attr('value');
	 
		if (this.checked || attr === '1' || attr === '2' || attr === '3' || attr === '4' || attr === '5' || attr === '6') {
	 
			$('#kapali').hide("slide", { direction: "left" }, 1000);
			$('#kapali2').hide("slide", { direction: "left" }, 1000);
			$('#kapali3').hide("slide", { direction: "left" }, 1000);
		}
		else {
			$('#kapali').show("slide", { direction: "left" }, 1000);
			$('#kapali2').show("slide", { direction: "left" }, 1000);
			$('#kapali3').show("slide", { direction: "left" }, 1000);
}

	});
	$('#terk').trigger('change');
});

$(document).ready(function () {
	$('#ulke').change(function () {
		var attr = $('#ulke option:selected').attr('value');

		if (attr !== '1') {
			$('#sehirgizle').fadeOut(700);
		} else {
			$('#sehirgizle').fadeIn(400);
}
	});
	$('#ulke').trigger('change');
});
$(document).ready(function () {
	$('#egitimID').change(function () {
		var attr = $('#egitimID option:selected').attr('value');

		if (attr == '1' || attr == '2' || attr == '3' || attr == '4' || attr == '5' || attr == '6') {
			$('#kapali').fadeOut(700);
			$('#kapali2').fadeOut(700);
			$('#kapali3').fadeOut(700);
		} else {
			$('#kapali').fadeIn(400);
			$('#kapali2').fadeIn(400);
			$('#kapali3').fadeIn(400);
		}
	});
	$('#egitimID').trigger('change');
});
$(document).ready(function () {
	$('#egitimDetayid').change(function () {
		var attr = $('#egitimDetayid option:selected').attr('value');

		if (attr == '1' || attr == '7') {
			$('#bolumkapa').fadeOut(700);
		 
		} else {
			$('#bolumkapa').fadeIn(400);
			 
		}
	});
	$('#egitimDetayid').trigger('change');
});


$(document).ready(function () {
	
	$('#terk').change(function () {
		var attr = $('#egitimID option:selected').attr('value');
		var bit = $('#bitist').val(null);
		var bit2 = $('#Notsistemi').val('0');
		var bit3 = $('#diplomanotu').val(null);
		if (this.checked || attr === '1' || attr === '2' || attr === '3' || attr === '4' || attr === '5' || attr === '6') {
			 
			bit;
			bit2;
			bit3;
		}


	});
	 

});