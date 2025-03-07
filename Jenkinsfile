pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/ldavidflorez/proyecto-jenkins.git'
            }
        }

        stage('Build') {
            steps {
                // sh './gradlew build' // Ajustar según tu tecnología
                echo "Building the project... No real build is performed."
            }
        }

        stage('Test') {
            steps {
                // sh './gradlew test' // Ajustar según tu framework de pruebas
                echo "Testing the project... No real tests are performed."
            }
        }

        stage('Deploy Simulation') {
            steps {
                echo "Simulating deployment... No real deployment is performed."
            }
        }
    }
}
