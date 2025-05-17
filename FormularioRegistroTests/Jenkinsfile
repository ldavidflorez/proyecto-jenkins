pipeline {
    agent any
    
    stages {
        stage('Restore') {
            steps {
                dir('FormularioRegistroTests') {
                    bat 'dotnet restore FormularioRegistroTests.sln'
                }
            }
        }

        stage('Build') {
            steps {
                dir('FormularioRegistroTests') {
                    bat 'dotnet build FormularioRegistroTests.sln --no-restore'
                }
            }
        }

        stage('Test') {
            steps {
                echo 'No tests defined yet.'
                dir('FormularioRegistroTests') {
                    bat 'dotnet test FormularioRegistroTests.sln --no-build --verbosity normal'
                }
            }
        }

        stage('Deploy Simulation') {
            steps {
                echo 'Simulating deployment...'
                echo 'Deploying application to staging environment (simulated).'
                // Aquí podrías poner un bat, curl, scp, kubectl, etc., en un escenario real
            }
        }
    }

    post {
        success {
            echo 'CI/CD pipeline completed successfully.'
        }
        failure {
            echo 'Pipeline failed.'
        }
    }
}
