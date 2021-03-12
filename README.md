# ApiRuleta-Test

#Instalación

1. cd ApiRuletaOnline
2. docker-compose up

#URl-Métodos
1. Crear Ruleta - POST {http://localhost:5000/api/roulette}
2. Lista de Ruletas - GET {http://localhost:5000/api/roulette}
3. Abrir Ruleta - PUT {http://localhost:5000/api/roulette/{{roulette_id}}/open}
4. Apostar en la ruleta actual - POST {http://localhost:5000/api/roulette/{{roulette_id}}/bet}
5. Cerrar Ruleta - PUT {http://localhost:5000/api/roulette/{{roulette_id}}/close}
