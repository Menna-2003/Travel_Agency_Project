let paypal = document.querySelector(".method1");
let paypalinput = document.querySelector(".method1 input");
let credit = document.querySelector(".method2");
let creditinput = document.querySelector(".method2 input");

let accountDetails = document.querySelector(".accountDetails");
let cardDetails = document.querySelector(".cardDetails");

accountDetails.style.display = "none";
cardDetails.style.display = "none";

paypal.addEventListener("click", (e) => {
    creditinput.removeAttribute("checked");
    paypalinput.setAttribute("checked", "true");

    if (paypalinput.hasAttribute("checked") == true) {
        accountDetails.style.display = "block";
        cardDetails.style.display = "none";
    }
});

credit.addEventListener("click", (e) => {
    paypalinput.removeAttribute("checked");
    creditinput.setAttribute("checked", "true");

    if (creditinput.hasAttribute("checked") == true) {
        cardDetails.style.display = "block";
        accountDetails.style.display = "none";
    }
});
