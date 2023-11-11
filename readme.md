# BIF5-SWKOM Software Component Systems Projekt

Willkommen zum BIF5-SWKOM Projekt an der FH Technikum Wien der Gruppe D (Mario Gussnig, Hofbauer Daniel). In diesem Projekt erstellen wir ein ein Dokumentenverwaltungssystem. Das Projekt konzentriert sich auf die Verwendung von Microservices, REST, OpenAPI, den Aufbau wiederverwendbarer Komponenten und die Anwendung fortschrittlicher Softwaretechnik-Konzepte.

### Zielarchitektur

Das Projekt folgt einer dreischichtigen Architektur, bestehend aus der Data Access Layer, der Business Layer und der Webservice Facade, wobei eine Webanwendung externe Clients bedient.

## Services starten

Um das Projekt zu starten, führen Sie den folgenden Befehl aus:

```bash
docker-compose up -d
```
Stelle sicher, dass die entsprechenden Umgebungsvariablen in `/.env' für PostgreSQL, RabbitMQ und pgAdmin gesetzt sind, um einen erfolgreichen Start zu gewährleisten. Nach dem Start kann man auf die Dienste per `localhost:80/` zugreifen und mit der Dokumentenverwaltung beginnen.

### Erforderliche Umgebungsvariablen:

- **PostgreSQL:**
  - `POSTGRES_DB`: swkom
  - `POSTGRES_USER`: swkom
  - `POSTGRES_PASSWORD`: [Ihr Passwort]

- **RabbitMQ:**
  - `RABBITMQ_HOST`: swkom-mq
  - `RABBITMQ_DEFAULT_USER`: swkom
  - `RABBITMQ_DEFAULT_PASS`: [Ihr Passwort]
  - `RABBITMQ_DEFAULT_QUEUE`: Default

- **pgAdmin:**
  - `PGADMIN_DEFAULT_EMAIL`: example@example.com
  - `PGADMIN_DEFAULT_PASSWORD`: [Ihr Passwort]


## Projektaufbau

### Sprint-Übersicht

Der Entwicklungsprozess ist in 7 Sprints organisiert, jeder dauert etwa 2 Wochen und folgt den Prinzipien von Scrum. Die Sprints sind darauf ausgelegt, aufeinander aufzubauen und kleine Iterationen zu verwenden, bei denen fest codierte Komponenten im Laufe der Zeit ersetzt werden.

- **Sprint 1:** REST API, OpenAPI, CI/CD
- **Sprint 2:** UI, Object Mapping, Validation
- **Sprint 3:** Data Access Layer, Repositories, O/R Mapper
- **Sprint 4:** Queueing, Dependency Injection, Logging, Code Review
- **Sprint 5:** Service Agent (OCR), Error Handling
- **Sprint 6:** Elastic Search, Use Cases
- **Sprint 7:** Integration Tests, Finalization, Code Review

### Frontend: Paperless-ngx

Als Frontend wird das UI von [Paperless-ngx](https://docs.paperless-ngx.com/) verwendet. Dieses Open-Source-Dokumentenverwaltungssystem ermöglicht die Verwandlung physischer Dokumente in ein durchsuchbares Online-Archiv. Das UI ist bereits vorab kompiliert (precompiled), da dieses Projekt auf die Implementierung eines Backends fokkusiert ist.

### API-Erstellung mit OpenAPI Contract

Für die API-Entwicklung wurde ein OpenAPI-Contract vom Kurs bereitgestellt. Dieser Vertrag dient als Grundlage für die Erstellung der RESTful API, die verschiedene Funktionalitäten des Dokumentenverwaltungssystems ermöglicht.

### Verwendete Technologien

Die Technologien, die im Projekt eingesetzt werden, umfassen:

- **Programmiersprache:** C#
- **Messaging-Queue:** RabbitMQ
- **Datenbank:** PostgreSQL
- **Versionskontrolle:** GitHub
- **Framework:** .NET 7.0
- **Suchmaschine:** ElasticSearch

### Docker-Container für Microservices

Ein Hauptziel des Projekts besteht darin, verschiedene Microservices zu entwickeln und in einer Docker-Umgebung bereitzustellen. Docker ermöglicht die Containerisierung der Microservices, was eine einfache Bereitstellung, Skalierbarkeit und Wartung ermöglicht.

Der Einsatz von Docker ist entscheidend, um eine konsistente und isolierte Umgebung für die einzelnen Microservices zu gewährleisten. Durch die Containerisierung können die Microservices unabhängig voneinander entwickelt, getestet und bereitgestellt werden.