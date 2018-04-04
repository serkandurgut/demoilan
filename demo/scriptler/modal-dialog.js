var TeamEditPostBackURL = '/Profil/Edit';
$(function () {
	$(".anchorDetail").click(function () {
		debugger;
		var $buttonClicked = $(this);
		var id = $buttonClicked.attr('data-id');
		var options = { "backdrop": "static", keyboard: true };
		$.ajax({
			type: "GET",
			url: TeamEditPostBackURL,
			contentType: "application/json; charset=utf-8",
			data: { "Id": id },
			datatype: "json",
			success: function (data) {
				debugger;
				$('#myModalContent').html(data);
				$('#myModal').modal(options);
				$('#myModal').modal('show');

			},
			error: function () {
				alert("Dynamic content load failed.");
			}
		});
	});
	//$("#closebtn").on('click',function(){
	//    $('#myModal').modal('hide');

	$("#closbtn").click(function () {
		$('#myModal').modal('hide');
	});
});
function testAnim(x) {
	$('.modal .modal-dialog').attr('class', 'modal-dialog' + x + 'animated');

	$('#myModal').on('show.bs.modal', function (e) {
		testAnim("fade in");
	})
	$('#myModal').on('hide.bs.modal', function (e) {

		testAnim("fade");
	})
};