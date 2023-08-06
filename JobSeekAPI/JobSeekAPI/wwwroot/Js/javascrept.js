const signup = document.querySelector(".signup");
const termcond = document.querySelector("#accept");
const password = document.querySelector("#password");
const confirmPassword = document.querySelector("#confirmPassword");
const pwd_format = document.querySelector(".pwd-format");
const passwordPattern = /^[a-zA-Z0-9]{8,15}$/



password.addEventListener('focusin', () => {
    pwd_format.style.display = 'block';

    // now lets check the password entered by the user
    password.addEventListener('keyup', () => {
        if (passwordPattern.test(password.value)) {
            password.style.borderColor = 'green ' // if password pattern matches the border of password input will ne green
            password.style.outline = 'green solid'
            pwd_format.style.color = 'green'
        } else {
            password.style.borderColor = 'red 1px'
            password.style.outline = 'red solid'
            pwd_format.style.color = 'red'
        }
    })
})
password.addEventListener('focusout', () => {
    pwd_format.style.display = 'none';

})
confirmPassword.addEventListener('focusin', () => {
    pwd_format.style.display = 'block'

    confirmPassword.addEventListener('keyup', () => {
        if (passwordPattern.test(confirmPassword.value) && confirmPassword.value === password.value) {
            confirmPassword.style.borderColor = 'green' // if password pattern matches the border of password input will ne green
            confirmPassword.style.outline = 'green solid'
            pwd_format.style.color = 'green'
        } else {
            confirmPassword.style.borderColor = 'red 1px'
            pwd_format.style.color = 'red'
            confirmPassword.style.outline = 'red solid'
        }
    })
})
confirmPassword.addEventListener('focusout', () => {
    pwd_format.style.display = 'none';

})
termcond.addEventListener('change', () => {
    if (termcond.checked === true) {
        signup.disabled = false;
    } else if (termcond.checked === false) {
        signup.disabled = true;
    }
})

const logIn = document.querySelector("#LoginId");
const firstname = document.querySelector("#firstName");
const lastname = document.querySelector("#lastName");
const title = document.querySelector("#Title");
const option = document.querySelector("#option");

logIn.addEventListener('click', () => {

    if (logIn.textContent === 'Login here') {
        firstname.style.display = 'none';
        lastname.style.display = 'none';
        confirmPassword.style.display = 'none';
        MovBack.style.display = 'none';
        MovNext.style.display = 'none';
        signup.style.display = 'block';
        signup.textContent = 'Login';
        title.textContent = 'LogIn';
        option.textContent = 'Don\'t have an account?';
        logIn.textContent = 'Sign Up here';
    }
    else {
        location.href = "MyPage.html";
    }

})

// var SwitchBtn = false;
var count = 0;
const MovNext = document.querySelector(".NextBtn");
const MovBack = document.querySelector(".BackBtn");




MovNext.addEventListener('click', () => {
    if (count < 3) {
        count++;
        firstname.style.display = 'none';
        lastname.style.display = 'none';
        confirmPassword.style.display = 'none';
        MovBack.disabled = false;
    }

})
MovBack.addEventListener('click', () => {
    if (count > 0) {
        count--;
        firstname.style.display = 'flex';
        lastname.style.display = 'flex';
        confirmPassword.style.display = 'flex';
        if (count == 0) {
            MovBack.disabled = true;
        }
    }


})


