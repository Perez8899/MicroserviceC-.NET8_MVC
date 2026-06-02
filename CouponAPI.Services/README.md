# 1. Crear rama para la API
git checkout -b feature/integracion-api

# 2. Hacer todos los cambios para consumir la API
# Modificar archivos: JavaScript, Controllers, etc.

# 3. Hacer commits frecuentes
git add .
git commit -m "Configurar HttpClient para la API"
git add .
git commit -m "Crear servicio para consumir API"
git add .
git commit -m "Mostrar datos en el frontend"

# 4. Cuando todo funciona perfecto, ir a main
git checkout main

# 5. Traer últimos cambios (si los hay)
git pull origin main

# 6. Fusionar tu rama (merge)
git merge feature/integracion-api

# 7. Subir a GitHub
git push origin main

# 8. Limpiar
git branch -d feature/integracion-api