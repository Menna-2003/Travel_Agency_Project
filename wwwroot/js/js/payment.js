let paypal = document.querySelector(".method1");
let paypalinput = document.querySelector(".method1 input");
let credit = document.querySelector(".method2");
let creditinput = document.querySelector(".method2 input");

let accountDetails = document.querySelector(".accountDetails");
let cardDetails = document.querySelector(".cardDetails");

let ccn = document.getElementById("ccn");
let expirydate = document.getElementById("expirydate");
let securityCode = document.getElementById("securityCode");
let email = document.getElementById("email");
let pass = document.getElementById("pass");

ccn.setAttribute("disabled", "");
expirydate.setAttribute("disabled", "");
securityCode.setAttribute("disabled", "");
email.setAttribute("disabled", "");
pass.setAttribute("disabled", "");

accountDetails.style.display = "none";
cardDetails.style.display = "none";

paypal.addEventListener("click", (e) => {
    creditinput.removeAttribute("checked");
    paypalinput.setAttribute("checked", "true");

    ccn.setAttribute("disabled", "");
    expirydate.setAttribute("disabled", "");
    securityCode.setAttribute("disabled", "");

    if (paypalinput.hasAttribute("checked") == true) {
        accountDetails.style.display = "block";
        cardDetails.style.display = "none";
        email.removeAttribute("disabled");
        pass.removeAttribute("disabled");
    }
});

credit.addEventListener("click", (e) => {
    paypalinput.removeAttribute("checked");
    creditinput.setAttribute("checked", "true");

    email.setAttribute("disabled", "");
    pass.setAttribute("disabled", "");

    if (creditinput.hasAttribute("checked") == true) {
        cardDetails.style.display = "block";
        accountDetails.style.display = "none";
        ccn.removeAttribute("disabled");
        expirydate.removeAttribute("disabled");
        securityCode.removeAttribute("disabled");
    }
});
