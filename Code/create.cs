@model JobPlacementDashboard.Models.JPBulletin

@using (Html.BeginForm())
{
    @Html.AntiForgeryToken()
<div id="form-horizontal">
    <div class="col-md-10" id="colStyle">

        <select id="dropdownId" class="dropdown-content" name="BulletinCategoryEnum">
            <option class="dropdown-item" value="disabled selected hiden">Select a Category</option>
            <option class="dropdown-item" value="0">Advice</option>
            <option class="dropdown-item" value="1">JobPosting</option>
            <option class="dropdown-item" value="2">Events</option>
        </select>
        <br/>
        <br/>

        @Html.ValidationMessageFor(model => model.BulletinCategoryEnum, "", new { @class = "text-danger" })
    </div>
    @Html.ValidationSummary(true, "", new { @class = "text-danger" })
    <div class="container " id="someStyles">
        <br />
        
        <div class="text-area" id="textAreaStyle">
            
            <form name="bulletin">
                <h6>Bulletin Posts</h6>
                <input type="button" value="&#182;" id="paragraphText" />
                <input type="button" value="B" id="boldText" />
                <input type="button" value="I" id="italicizeText" />
                <input type="button" value="U" id="underLineText" />
                <div class="dropdown-wrapper">
                    <input type="button" value="&#128474" class="dropbtn" onclick="myFunction()" />
                    <ul id="myDropdown" class="dropdown-content hide">
                        <li onClick="handleFontSize(12)">12</li>
                        <li onClick="handleFontSize(14)">14</li>
                        <li onClick="handleFontSize(16)">16</li>
                        <li onClick="handleFontSize(18)">18</li>
                        <li onClick="handleFontSize(20)">20</li>
                        <li onClick="handleFontSize(22)">22</li>
                        <li onClick="handleFontSize(24)">24</li>
                        <li onClick="handleFontSize(26)">26</li>
                        <li onClick="handleFontSize(28)">28</li>
                        <li onClick="handleFontSize(30)">30</li>
                        <li onClick="handleFontSize(32)">32</li>
                        <li onClick="handleFontSize(34)">34</li>
                    </ul>
                </div>
                <input type="button" value="&#9776" id="centerText" />
                <input type="button" value="&#128279;" id="addLink" />
                <input type="button" value="&#x1f4f7" id="addImage" />
                <input type="file" id="my_file" />

                <br />
                <!--<p style="text-align:left">Bulletin Posts</p>-->
                <textarea class="text_edit" id="bulletinBody" name="BulletinBody"></textarea>
                <br />
                <input type="submit" value="Create" class="btn btn-default" />
            </form>
        </div>
        <br />
        @Html.ActionLink("Back to List", "Index")
    </div>
</div>
}
<!--Modal-->
<div class="modal" id="myModal">
    <div class="modal-dialog">
        <div class="modal-content">

            <!-- Modal Header -->
            <div class="modal-header">
                <h4 class="modal-title">Modal Heading</h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>

            <!-- Modal body -->
            <div class="modal-body">
                Modal body..
            </div>

            <!-- Modal footer -->
            <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>

@section Scripts {
    @Scripts.Render("~/bundles/jqueryval")
    <script type="text/javascript">

        function wrapText(openTag, closeTag, styleTag) {
            var textarea = document.getElementById("bulletinBody");
            if (openTag && styleTag) {
                let splitTag = openTag.split('>');
                splitTag[0] = splitTag[0] + ' style="' + styleTag+'"';
                openTag = splitTag.join(">");
            }
            if (textarea.selectionStart != undefined) {
                if (textarea.selectionStart != textarea.selectionEnd) {
                    var newText = textarea.value.substring(0, textarea.selectionStart) +
                        openTag + textarea.value.substring(textarea.selectionStart, textarea.selectionEnd) + closeTag +
                        textarea.value.substring(textarea.selectionEnd);
                    textarea.value = newText;
                }
            }
            else {
                // For older browsers
                var textRange = document.selection.createRange();
                var rangeParent = textRange.parentElement();
                if (rangeParent === textarea) {
                    textRange.text = openTag + textRange.text + closeTag;
                }
            }
        }
        $("#boldText").click(function () {
            wrapText('<b>', '</b>');
        });

        $("#italicizeText").click(function () {
            wrapText('<i>', '</i>');
        });

        $("#underLineText").click(function () {
            wrapText('<u>', '</u>');
        });


        function getSize() {
            size = $("h1").css("font-size");
            size = parseInt(size, 10);
            $("#font-size").text(size);
        }

        //get inital font size
        getSize();

        $("#up").on("click", function () {

            // parse font size, if less than 50 increase font size
            if ((size + 2) <= 50) {
                $("h1").css("font-size", "+=2");
                $("#font-size").text(size += 2);
            }
        });

        $("#down").on("click", function () {
            if ((size - 2) >= 12) {
                $("h1").css("font-size", "-=2");
                $("#font-size").text(size -= 2);
            }
        });

        $("#paragraphText").click(function () {
            wrapText('<p>', '</p>');
        });


        $("#addLink").click(function () {
            var x;
            x = prompt("Please enter URL or Specific File Path");
            if (x != "" && x != null) {
                var lowerInput = x.toLowerCase();
                var includesURL = (lowerInput.includes("http://") || lowerInput.includes("www."));
                if (includesURL) {
                    var $text = $("#bulletinBody");
                    $text.val($text.val() + ("<a href =" + '"' + x + '"' + 'target="_blank"' + '></a>'));
                } else {
                    var $text = $("#bulletinBody");
                    $text.val($text.val() + ("<img src=" + '"' + x + '"' + '>'));
                }
            }
        });

        //Custom image upload button
        document.getElementById('addImage').onclick = function () {
            document.getElementById('my_file').click();
        };

        document.getElementById("my_file").addEventListener('change', function () {
            if (this.value != "" && this.value != null) {
                var $text = $("#bulletinBody");
                $text.val($text.val() + ("<img src=" + '"' + this.value + '"' + '>'));
            }
        });
     
        //For the Modal
        $("#fade").modal({
            fadeDuration: 100
        });
        /* When the user clicks on the button, 
        toggle between hiding and showing the dropdown content */
        function myFunction() {
            console.log('ran!');
            document.getElementById("myDropdown").classList.toggle("hide");
        }

        function handleFontSize(size) {
            const fontStyle = "font-size: " + size + "px";
            wrapText('<span>', '</span>', 'font-size: '+size+'px');
        }

        // Close the dropdown menu if the user clicks outside of it
        window.onclick = function (event) {
            console.log('window click');
            const target = event.target;
            if (!target.matches('.dropbtn')) {
                const dropdown = document.getElementById("myDropdown");
                if (!dropdown.classList.contains('hide')) {
                    dropdown.classList.add('hide');
                }
            }
        }
   
    </script>
}