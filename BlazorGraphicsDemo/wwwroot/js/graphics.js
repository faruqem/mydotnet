window.graphicsDemo = {
    init: function (canvasId) {
        const canvas = document.getElementById(canvasId);
        const ctx = canvas.getContext("2d");

        let particles = [];
        const colors = ["#ff6b6b", "#6bc5ff", "#6bff95", "#ffe66b", "#b16bff"];

        // Create particles
        for (let i = 0; i < 120; i++) {
            particles.push({
                x: Math.random() * canvas.width,
                y: Math.random() * canvas.height,
                r: 3 + Math.random() * 5,
                dx: -2 + Math.random() * 4,
                dy: -2 + Math.random() * 4,
                color: colors[Math.floor(Math.random() * colors.length)]
            });
        }

        function draw() {
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            for (let p of particles) {
                ctx.beginPath();
                ctx.arc(p.x, p.y, p.r, 0, Math.PI * 2);
                ctx.fillStyle = p.color;
                ctx.fill();

                // Move
                p.x += p.dx;
                p.y += p.dy;

                // Bounce off edges
                if (p.x < 0 || p.x > canvas.width) p.dx *= -1;
                if (p.y < 0 || p.y > canvas.height) p.dy *= -1;
            }
            requestAnimationFrame(draw);
        }
        draw();
    }
};