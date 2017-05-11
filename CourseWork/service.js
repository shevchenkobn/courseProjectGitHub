
document.addEventListener("click", function() {
		var s = window.getSelection(), t = s.anchorNode;
		var output = "";
		if (s.type == "Range")
		{
			if(s.baseNode == s.focusNode)
				output = t.data.substring(s.baseOffset, s.focusOffset);
			else
			{
				var textNodes = s.baseNode.parentNode.childNodes;
				var baseNode, baseOffset, focusNode, focusOffset;
				for (var i = 0; i < textNodes.length; i++)
				{
					if (textNodes[i] == s.baseNode)
					{
						baseNode = s.baseNode, baseOffset = s.baseOffset, focusNode = s.focusNode, focusOffset = s.focusOffset;
						break;
					}
					else
					{
						baseNode = s.focusNode, baseOffset = s.focusOffset, focusNode = s.baseNode, focusOffset = s.baseOffset;
						break;
					}
				}
				for (var i = 0; i < textNodes.length; i++)
				{
					if (Object.prototype.toString.call(textNodes[i]) === "[object Text]")
					{
						if (output === "")
						{
							if (textNodes[i] == baseNode)
								output = baseNode.data.substring(baseOffset);
						}
						else
						{
							if (textNodes[i] == focusNode)
							{
								output += focusNode.data.substring(0, focusOffset);
							}
							else
								output += textNodes[i].data;
						}

					}

				}
			}
		}
		else
		{
			var start = s.baseOffset, end = s.focusOffset, regex = /[()., _!@#$%^&*\\|/?<>`~]/;
			while (start > 0 && !regex.test(t.data[start-1]))
			{
				start--;
			}
			while (end < t.length - 1 && !regex.test(t.data[end]))
			{
				end++;
			}
			output = t.data.substring(start, end);
		}
		//console.log(output);
		markAll(output, false);
		OSMJIF.sendMessage("textIsClicked", output);
	});

function markAll(key, isScrolling)
{
	var markParam = { "separateWordSearch": false };
	var body = $("body");
	body.unmark();
	body.mark(key, markParam);
	if (isScrolling)
		document.querySelector("mark").scrollIntoView(true);
	// console.log($("mark:visible:first"));
	// console.log($("#sidebar"));
	// $('body').animate({
 //    scrollTop: $("mark:visible:first").offset().top
	// }, 1000);
	// console.log($("mark:visible:first").offset().top);
	// window.scrollTo(0, $("mark:visible:first").offset().top);
	// $('#lol').animate({
 //    scrollTop: $("#lol").offset().top
	// }, 1000);
}
function removeMarks()
{
	$("body").unmark();
}