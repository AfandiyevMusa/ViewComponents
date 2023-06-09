(document).ready(function ()
{
    console.log("second");
    $(document).on("click", ".status-slider", function () {
        console.log("second");
        //let productId = $(this).attr("data-id");

        //let data = { id: productId };

        //$.ajax({
        //    url: "cart/addbasket",
        //   type: "Post",
        //   data: data,
        //   success: function (res) {
        //        $("sup.rounded-circle").text(res)
        //   }
        //})
    }) 
})

//document.addEventListener("DOMContentLoaded", function () {
//    document.addEventListener("click", function (event) {
//        if (event.target.classList.contains("status-slider")) {
//            console.log(event.target);
//            let productId = event.target.getAttribute("data-id");

//            let data = { id: productId };

//            var xhr = new XMLHttpRequest();
//            xhr.open("POST", "cart/addbasket", true);
//            xhr.setRequestHeader("Content-Type", "application/json");
//            xhr.onreadystatechange = function () {
//                if (xhr.readyState === 4 && xhr.status === 200) {
//                    var res = xhr.responseText;
//                    document.querySelector("sup.rounded-circle").textContent = res;
//                }
//            };
//            xhr.send(JSON.stringify(data));
//        }
//    });
//});
