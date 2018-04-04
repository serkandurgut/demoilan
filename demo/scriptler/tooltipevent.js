$(function () {
	$(document).tooltip({
		position: {
			my: "center bottom-20",
			at: "center top",
			using: function (position, feedback) {
				$(this).css(position);
				$("<div>")
					.addClass("arrow")
					.addClass(feedback.vertical)
					.addClass(feedback.horizontal)
					.appendTo(this);
			}
		},
		onShow: function () {
			this.getTrigger().fadeTo("slow", 1000)
		},
		events: {
			input: 'mouseover  click, blur'
		}, show: { effect: "blind", duration: 800 },

		hide: { effect: "puff", duration: 800 },

	});
});
