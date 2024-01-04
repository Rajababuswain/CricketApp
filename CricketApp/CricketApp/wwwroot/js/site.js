// Import necessary CSS classes for animation
const SUCCESS_ANIMATION_CLASS = "animate-success";
const ERROR_ANIMATION_CLASS = "animate-error";

function toggleAnimation(element, className) {
    element.classList.add(className);
    setTimeout(() => {
        element.classList.remove(className);
    }, 1000);
}

function validateRegistration() {
    // Get form elements
    const username = document.getElementById('username');
    const email = document.getElementById('email');
    const password = document.getElementById('password');
    const confirmPassword = document.getElementById('confirmPassword');
    const termsCheckbox = document.getElementById('termsCheckbox');
    const messageEl = document.getElementById('registrationMessage');

   


    const newsToggle = document.getElementById('latest-news');
    const newsContent = document.getElementById('latest-news-content');

    newsToggle.addEventListener('click', () => {
        newsContent.style.display = newsContent.style.display === 'none' ? 'block' : 'none';
    });

    const matchesToggle = document.getElementById('upcoming-matches');
    const matchesList = document.getElementById('upcoming-matches-list');

    matchesToggle.addEventListener('click', () => {
        matchesList.style.display = matchesList.style.display === 'none' ? 'block' : 'none';
    });

    const statsToggle = document.getElementById('player-statistics');
    const statsTable = document.getElementById('player-stats-table');

    statsToggle.addEventListener('click', () => {
        statsTable.style.display = statsTable.style.display === 'none' ? 'block' : 'none';
    });



    // Clear any previous errors
    messageEl.textContent = '';

    // Username validation
    if (!username.value) {
        messageEl.textContent = 'Please enter a username.';
        setDynamicColor(messageEl, "#dc3545");
        toggleAnimation(messageEl, ERROR_ANIMATION_CLASS);
        return false;
    }

    // Email validation
    if (!/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+<span class="math-inline">/\.test\(email\.value\) \) \{
        messageEl\.textContent \= 'Please enter a valid email address\.';
setDynamicColor\(messageEl, "\#dc3545"\);
        toggleAnimation\(messageEl, ERROR\_ANIMATION\_CLASS\);
        return false;
        \
    }
    // Password validation
    if \(\!/^\(?\=\.\*\\d\)\(?\=\.\*\[a\-z\]\)\(?\=\.\*\[A\-Z\]\)\.\{8,\}</span > /.test(password.value)) {
    messageEl.textContent = 'Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one number.';
    setDynamicColor(messageEl, "#dc3545");
    toggleAnimation(messageEl, ERROR_ANIMATION_CLASS);
    return false;
}

// Confirm password validation
if (confirmPassword.value !== password.value) {
    messageEl.textContent = 'Passwords do not match.';
    setDynamicColor(messageEl, "#dc3545");
    toggleAnimation(messageEl, ERROR_ANIMATION_CLASS);
    return false;
}

// Terms checkbox validation
if (!termsCheckbox.checked) {
    messageEl.textContent = 'You must agree to the terms of service and privacy policy.';
    setDynamicColor(messageEl, "#dc3545");
    toggleAnimation(messageEl, ERROR_ANIMATION_CLASS);
    return false;
}

// All validations passed, proceed with registration
registerUser({
    username: username.value,
    email: email.value,
    password: password.value
});

return true;
}

function registerUser(userData) {
    // Replace "YOUR_API_ENDPOINT" with your actual API endpoint
    fetch('YOUR_API_ENDPOINT/register', {
        method: 'POST',
        body: JSON.stringify(userData),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(response => {
        if (response.ok) {
            // User registered successfully
            messageEl.textContent = 'Registration successful! Please check your email for verification.';
            setDynamicColor(messageEl, "#007bff");
            toggleAnimation(messageEl, SUCCESS_ANIMATION_CLASS);

            // Clear form fields after successful registration
            username.value = '';
            email.value = '';
            password.value = '';
            confirmPassword.value = '';
            termsCheckbox.checked = false;
        } else {
            response.json().then(error => {
                messageEl.textContent = error.message;
                setDynamicColor(messageEl, "#dc3545");
                toggleAnimation(messageEl, ERROR_ANIMATION_CLASS);
            });
        }
    })
}

function validateLogin() {
    const email = document.getElementById("username").value;
    const password = document.getElementById("password").value;
    const loginMessage = document.getElementById("loginMessage");

    // Email format validation
    if (!isValidEmail(email)) {
        loginMessage.innerText = "Please enter a valid email address.";
        setDynamicColor(loginMessage, "#dc3545
