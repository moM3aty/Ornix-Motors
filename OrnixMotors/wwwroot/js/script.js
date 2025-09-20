// Preloader
window.addEventListener('load', () => {
    const preloader = document.querySelector('.preloader');
    preloader.classList.add('fade-out');
});

// Sticky Navbar
const header = document.querySelector('.header');
window.addEventListener('scroll', () => {
    if (window.scrollY > 50) {
        header.classList.add('scrolled');
    } else {
        header.classList.remove('scrolled');
    }
});

// Mobile Menu
const menuIcon = document.querySelector('.menu-icon');
const navLinks = document.querySelector('.nav-links');
const allLinks = document.querySelectorAll('.nav-links a'); // تحديد كل الروابط

if (menuIcon && navLinks) {
    // لفتح وإغلاق القائمة عند الضغط على الأيقونة
    menuIcon.addEventListener('click', () => {
        navLinks.classList.toggle('active');
    });

    // لإغلاق القائمة عند الضغط على أي رابط بداخلها (مهم لتجربة المستخدم)
    allLinks.forEach(link => {
        link.addEventListener('click', () => {
            navLinks.classList.remove('active');
        });
    });
}

// Scroll Animation
const scrollElements = document.querySelectorAll('.animate-on-scroll');

const observer = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('is-visible');
        }
    });
}, {
    threshold: 0.1 
});

scrollElements.forEach(el => {
    observer.observe(el);
});



// ======================= Counter-Up Animation (IMPROVED & FASTER) =======================

const counters = document.querySelectorAll('.counter');

const animateCounter = (counter) => {
    const target = +counter.getAttribute('data-target');
    const duration = 2000; // مدة الأنيميشن بالمللي ثانية (2 ثانية)
    const stepTime = 10;
    const totalSteps = duration / stepTime;
    const increment = target / totalSteps;

    let currentCount = 0;

    const updateCounter = () => {
        currentCount += increment;

        if (currentCount < target) {
            counter.innerText = Math.ceil(currentCount).toLocaleString(); // استخدام toLocaleString لإضافة الفواصل (e.g., 15,000)
            setTimeout(updateCounter, stepTime);
        } else {
            counter.innerText = target.toLocaleString();
        }
    };

    updateCounter();
};

const counterObserver = new IntersectionObserver((entries, observer) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            animateCounter(entry.target);
            observer.unobserve(entry.target); // لتشغيل الأنيميشن مرة واحدة فقط
        }
    });
}, {
    threshold: 0.5
});

counters.forEach(counter => {
    counterObserver.observe(counter);
});