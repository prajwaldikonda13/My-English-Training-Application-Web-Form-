
function makeMoves(object) {
    var secondRow = $("#dummyTable").find("tr").not(".td-city tr").eq(1)
    var thirdRow = $("#dummyTable").find("tr").not(".td-city tr").eq(2)
    var emptyCellInSecondRow = $(secondRow).find("td").not(".td-city td").eq(2)
    var emptyCellInThirdRow = $(thirdRow).find("td").not(".td-city td").eq(1)
    var serverPanel = $("#serverPanel")
    emptyCellInSecondRow.html(serverPanel.html())
    var string = JSON.stringify(object)
    var array = JSON.parse(string)
    $(".forDots").html("")
    for (var i = 0; i < array.length; i++) {
        var player = array[i];
        var $table = $(".forDots-" + player.CurrentPosition)
        var cells = $table.find("td")
        if (cells.length == 0)
            $table.append("<tr><td><i class='fas fa-chess-king' style='font-size:4rem;color:" + player.Color + "'></i></td></tr>")
        else if (cells.length == 1) {
            var $parent = $(cells[0]).parent()
            $parent.append("<td><i class='fas fa-chess-king' style='color:" + player.Color + "'></i></td>")
            $parent.find("i").css("font-size", "3.5rem")
        }
        else if (cells.length == 2) {
            var $grandParent = $(cells[0]).parent().parent()
            $grandParent.append("<tr><td><i class='fas fa-chess-king' style='color:" + player.Color + "'></i></td></tr>")
            $grandParent.find("i").css("font-size", "2rem")
        }
        else if (cells.length == 3) {
            var $parent = $(cells[2]).parent()

            $parent.append("<td><i class='fas fa-chess-king' style='color:" + player.Color + "'></i></td>")
            $grandParent.find("i").css("font-size", "2rem")
        }
    }
}
function arrangeCities() {
    var cities = $(".td-city")
    var topRow = cities.slice(0, 10)
    var rightRow = cities.slice(10, 18)
    var bottomRow = cities.slice(18, 28).get().reverse()
    var leftRow = cities.slice(28, 36).get().reverse()
    $("#topRow").append(topRow)
    $("#bottomRow").append(bottomRow)
    for (var i = 0; i < 8; i++)
        $("<tr><td class='td-city text-center' data-toggle='modal' data-target='#myModal'>" + leftRow[i].innerHTML + "</td><td colspan=3></td><td colspan=2></td><td colspan=3></td><td class='td-city text-center' data-toggle='modal' data-target='#myModal'>" + rightRow[i].innerHTML + "</td></tr>").insertBefore("#bottomRow")
    $("#MainTable").remove()
}
function openCardAtClient(locationIndex)
{
    var $table = $(".forDots-" + locationIndex)
    $table.click()
}