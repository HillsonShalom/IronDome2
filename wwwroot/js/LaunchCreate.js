let ThreatIndex = 1;
document.getElementById('add-threat').addEventListener('click', function () {
    const container = document.getElementById('threat-container');
    const ThreatHtml = `
                <div class="form-group">
                    <label for="Threats_${ThreatIndex}__Weapon" class="control-label">Book Name</label>
                    <input name="Threats[${ThreatIndex}].Weapon" class="form-control" />
                    <span asp-validation-for="Threats[${ThreatIndex}].Weapon" class="text-danger"></span>
                </div>`;
    container.insertAdjacentHTML('beforeend', ThreatHtml);
    ThreatIndex++;
});