import { useI18n } from 'vue-i18n'

export default function () {
  const { t } = useI18n()

  const dateRules = [val => !!val || t('mandatory_field')]
  const textRules = [val => !!val || t('mandatory_field'), val => val.length > 2 || t('short_input')]
  const numberOnlyRule = [val => !isNaN(val) || t('not_a_valid_number')]

  return {
    dateRules,
    textRules,
    numberOnlyRule
  }
}
