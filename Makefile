ef:
	docker compose -f compose.development.yml exec api dotnet ef $(filter-out $@,$(MAKECMDGOALS))

%:
	@: